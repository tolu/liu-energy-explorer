<?php

ini_set('error_reporting', E_ALL);

set_include_path(get_include_path() . PATH_SEPARATOR . 'lib/');

include 'PHPExcel.php';
include 'PHPExcel/IOFactory.php';

require_once 'DBConnection.php';
require_once 'DataItem.php';
require_once 'DataItemPeer.php';
require_once 'ExcelPointer.php';
require_once 'DataProcessing.php';

DBConnection::init();

// config
$bIncludeCountries = true;

$aCountries = include('lib/countryCodes3.inc.php');

$objPHPExcel = new PHPExcel();

//$aAllCountries = DataItemPeer::getAllCountries();
//$aAllYears = DataItemPeer::getAllYears();
//$aAllVars = DataItemPeer::getAllVariables();

$aAllYears = array(1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005);

$aAllVars = array(
		'energy_use_per_capita' => 'Energy use per capita',
		'electric_consumption' => 'Electric energy consumption per capita',
		'computers' => 'Computers per 100 pop', 
		'internet_users' => 'Internet users per 100 pop',
		'employment_rate' => 'Empoyment rate %',
		'infant_mortality' => 'Infant mortality %%',
		'greenhouse_gas' => 'Greenhouse gases per capita',		
		'export_percent_gdp' => 'Export % of GDP',
		'import_percent_gdp' => 'Import % of GDP',
		'gdp_per_capita' => 'GDP per capita',
		'gdp_anual_growth' => 'GDP anual growth',
		'pop_urban' => 'Urban population %',
		'pop_total' => 'Total population',

		//'unemployment_rate' => 'Unemployment rate', 
		//'pop_below_poverty' => 'Below poverty line %',
		//'export' => 'Export % of GDP',
		//'import' => 'Import % of GDP', 
		//'gdp_growth_rate' => 'GDP growth rate',
		//'life_expectancy' => 'Life expectancy',
		//'child_mortality_rate' => 'Child mortality rate',
		//'surface_area' => 'Area',
		//'energy_supply' => 'Energy supply',		
		//'energy_use' => 'Energy use / 1k GDP',
		//'electric_energy' => 'Electric energy kW / 1k pop',


		//'gdp_national'
		//'gdp'
		//'population'
	);

$aAllVarNames = array_keys($aAllVars);

$iSheetNr = 0;
foreach ($aAllYears as $iYear)
{
	echo 'Assembling year ' . $iYear . '...';
	
	$oExcelPointer = new ExcelPointer();	
	
	if ($iSheetNr != 0)
	{
		$objPHPExcel->createSheet();
	}
	$objPHPExcel->setActiveSheetIndex($iSheetNr);


	if ($bIncludeCountries)
	{
		$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), 'Code');
		$oExcelPointer->colStep();
		$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), 'Country');
		$oExcelPointer->colStep();
	}
	
	foreach ($aAllVars as $sVar)
	{
		$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), $sVar);
		$oExcelPointer->colStep();
	}

	
	foreach ($aCountries as $sCountry => $sCountryCode)
	{
		$oExcelPointer->rowStep();
		$oExcelPointer->resetColPointer();
		
		if ($bIncludeCountries)
		{
			$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), $sCountryCode);
                        $oExcelPointer->colStep();
			$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), $sCountry);
			$oExcelPointer->colStep();
		}

		$aCountryYearData = DataItemPeer::getDataByCountryCodeAndYear($sCountryCode, $iYear);
		$aCountryYearData = DataProcessing::process($aCountryYearData, $aAllVars);
		
		foreach ($aCountryYearData as $sVariable => $mValue)
		{
			$objPHPExcel->getActiveSheet()->setCellValue($oExcelPointer->getPointer(), $mValue);
			$oExcelPointer->colStep();
		}
	}

	$objPHPExcel->getActiveSheet()->setTitle($iYear);
	
	$iSheetNr++;
	
	echo "done!\n";
}
	
// Set active sheet index to the first sheet, so Excel opens this as the first sheet
$objPHPExcel->setActiveSheetIndex(0);

		
// Save Excel 2007 file
$objWriter = PHPExcel_IOFactory::createWriter($objPHPExcel, 'Excel5');
$objWriter->save('data.xls');





