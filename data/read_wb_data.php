<?php

ini_set('error_reporting', E_ALL);

require_once 'lib/DBConnection.php';
require_once 'lib/DataItem.php';
 
DBConnection::init();

$sDataDir = 'data/';
$sRawHeaderDelimiter = ',';
$sDataDelimiter = "\t";
$sHeaderDelimiter = ',';
$sEmptyDataPoint = '..';

$aDataConfig = array(
					'EG.USE.ELEC.KH.PC' => 'electric_consumption', 
					"EG.USE.PCAP.KG.OE" => 'energy_use_per_capita',
					"NE.EXP.GNFS.ZS" => 'export_percent_gdp',
					"NE.IMP.GNFS.ZS" => 'import_percent_gdp',
					"SP.DYN.LE00.IN" => 'life_expectancy',
					"SH.DYN.MORT" => 'child_mortality_rate',
					"AG.SRF.TOTL.K2" => 'surface_area',
					"NY.GDP.MKTP.KD.ZG" => 'gdp_anual_growth',
					"SP.POP.TOTL" => 'pop_total',
				);


//"Series Name","Series Code","Country Name","Country Code","YR1985","YR1986","YR1987","YR1988","YR1989","YR1990","YR1991","YR1992","YR1993","YR1994","YR1995","YR1996","YR1997","YR1998","YR1999","YR2000","YR2001","YR2002","YR2003","YR2004","YR2005","YR2006","YR2007",
//"Electric power consumption (kWh per capita)"	"EG.USE.ELEC.KH.PC"	"Afghanistan"	"AFG"	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	".."	

$aRawData = file($sDataDir . 'all_wb_data.csv');

// first row is variable names + years
$aYears = explode($sHeaderDelimiter, $aRawData[0]);
unset($aRawData[0]);

$aYears = array_slice($aYears, 4, count($aYears) - 5);
$aYears = str_replace(array('"', 'YR'), array('', ''), $aYears);

foreach ($aRawData as $sDataRow)
{
	$aData = explode($sDataDelimiter, $sDataRow);
	$aData = str_replace(array('"'), array(''), $aData);

	$sCountryCode = $aData[3];
	$sVariable = $aDataConfig[$aData[1]];
	$aYearData = array_slice($aData, 4, count($aData) - 5);
	
	foreach($aYearData as $iValueIndex => $mDataValue)
	{
		if ($mDataValue != $sEmptyDataPoint)
		{
			$oDataItem = new DataItem(	$sCountryCode,
										$aYears[$iValueIndex],
										$sVariable,
										$mDataValue);
			
			$oDataItem->save();	
		}
	}
}
