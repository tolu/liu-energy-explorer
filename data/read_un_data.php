<?php

ini_set('error_reporting', E_ALL);
//ini_set('error_log', 'error.log');
//$hej = array();
//echo $hej["sd"];

require_once 'lib/DBConnection.php';
require_once 'lib/DataItem.php';
 
DBConnection::init();

$sDataDir = 'data/';
$sDataFileExt = '.csv';

$aCountryCodes = include('lib/countryCodes3.inc.php');

$aDirScanSkip = array('.', '..', '.svn', 'EU');

// Format array: (country, year, value)
$aDataSources = array(
					'computers' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'employment_rate' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'energy_supply' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'energy_use' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'electric_energy' => array('delimiter' => ';', 'format' => array(0, 1, 3)),
					'gdp_per_capita' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'gdp_growth_rate' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'gdp_national' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'greenhouse_gas' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'internet_users' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'import' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'export' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'gdp' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'infant_mortality' => array('delimiter' => ';', 'format' => array(0, 1, 2)), // bara vart 5:e �r
					'pop_urban' => array('delimiter' => ';', 'format' => array(0, 1, 3)),
					'pop_below_poverty' => array('delimiter' => ';', 'format' => array(0, 1, 2)),
					'unemployment_rate' => array('delimiter' => ';', 'format' => array(0, 2, 5), 'multi_row' => true),
				);

$aSkipCountries = array(
						'China, Hong Kong Special Administrative Region',
						'Occupied Palestinian Territory',
						'Palestinian Territory, Occupied',
						'Congo',
						'East Timor',
						'Hong Kong SAR',
						'Timor-Leste',
						'Africa',
						'Asia',
						'Australia/New Zealand',
						'Central America',
						'Eastern Africa',
						'Eastern Asia',
						'Eastern Europe',
						'Euro Area',
						'Europe',
						'Middle Africa',
						'More developed regions',
						'Northern Africa',
						'Northern America',
						'Northern Europe',
						'South America',
						'South-Central Asia',
						'South-Eastern Asia',
						'Southern Africa',
						'Southern Europe',
						'Western Africa',
						'Western Asia',
						'Western Europe',
						'World',
						'Least developed countries',
						'Less developed regions',
						'Less developed regions, excluding China',
						'Less developed regions, excluding least developed countries',
						'European Community',
						'Sub-Saharan Africa',
						'Latin America and the Caribbean',
						'Channel Islands',
						'Caribbean',
						'Melanesia',
						'Micronesia',
						'Micronesia, Federated States of',
						'Oceania',
						'Polynesia',
						'Holy See',
						'Serbia and Montenegro',
					);
				
$aCountryAliases = array(
						'China, Macao Special Administrative Region' => 'Macau',
						'Macau (SAR)' => 'Macau',
						'Macau SAR' => 'Macau',
						'Cote dIvoire' => 'Ivory Coast',
						'Iran (Islamic Republic of)' => 'Iran',
						'Iran(Islamic Rep. of)' => 'Iran',
						'Korea, Republic of' => 'South Korea',
						'Korea Rep' => 'South Korea',
						'Republic of Korea' => 'South Korea',
						'Korea, Democratic Peoples Republic of' => 'North Korea',
						'Korea,Dem.Ppls.Rep.' => 'North Korea',
						'Democratic Peoples Republic of Korea' => 'North Korea',
						'Lao Peoples Democratic Republic' => 'Laos',
						'Lao Peoples Dem. Rep.' => 'Laos',
						'Lao PDR' => 'Laos',
						'Libyan Arab Jamahiriya' => 'Libya',
						'Libyan Arab Jamah.' => 'Libya',
						'Myanmar' => 'Myanmar (Burma)',
						'Faeroe Islands' => 'Faroe Islands',
						'Russian Federation' => 'Russia',
						'Saint Kitts and Nevis' => 'St. Kitts and Nevis',
						'St. Kitts-Nevis' => 'St. Kitts and Nevis',
						'Saint Lucia' => 'St. Lucia',
						'Saint Vincent and the Grenadines' => 'St. Vincent and the Grenadines',
						'St. Vincent-Grenadines' => 'St. Vincent and the Grenadines',
						'St Vincent and the Grenadines' => 'St. Vincent and the Grenadines',
						'St. Helena and Depend.' => 'St. Helena',
						'Saint Helena' => 'St. Helena',
						'Saint Pierre and Miquelon' => 'St. Pierre and Miquelon',
						'St. Pierre-Miquelon' => 'St. Pierre and Miquelon',
						'Samoa' => 'Western Samoa',
						'Syrian Arab Republic' => 'Syria',
						'The former Yugoslav Republic of Macedonia' => 'Macedonia',
						'T.F.Yug.Rep. Macedonia' => 'Macedonia',
						'United Republic of Tanzania' => 'Tanzania, United Republic of',
						'Viet Nam' => 'Vietnam',
						'Bahamas' => 'Bahamas, The',
						'Belarus' => 'Byelarus',
						'Central African Rep.' => 'Central African Republic',
						'Côte dIvoire' => 'Ivory Coast',
						'Dem. Rep. of Congo' => 'Congo',
						'Democratic Republic of the Congo' => 'Congo',
						'Falkland Is. (Malvinas)' => 'Falkland Islands (Islas Malvinas)',
						'Falkland Islands (Malvinas)' => 'Falkland Islands (Islas Malvinas)',
						'France incl. Monaco' => 'France',
						'Italy and San Marino' => 'Italy',
						'Norway, Svlbd. J.Myn.Isl.' => 'Norway',
						'Palau' => 'Pacific Islands (Palau)',
						'Réunion' => 'Reunion',
						'United States of America' => 'United States',
						'Tanzania' => 'Tanzania, United Republic of',
						'United Rep.Tanzania' => 'Tanzania, United Republic of',
						'Venezuela (Bolivarian Republic of)' => 'Venezuela',
						'United States Virgin Is.' => 'Virgin Islands',
						'United States Virgin Islands' => 'Virgin Islands',
						'Isle of Man' => 'Man, Isle of',
						'Switzrld,Liechtenstein' => 'Switzerland',
						'Republic of Moldova' => 'Moldova',
						'Wallis and Futuna Islands' => 'Wallis and Futuna',
						'Pitcairn' => 'Pitcairn Islands',
						'Yemen ' => 'Yemen',
						'Somalia ' => 'Somalia',
						'Brunei Darussalam' => 'Brunei',
					);
					
				
$aDataDirScan = scandir($sDataDir);

foreach ($aDataDirScan as $sDataFile)
{
	// skip this file?
	if (in_array($sDataFile, $aDirScanSkip))
	{
		continue;
	}
	
	$sVariableName = substr($sDataFile, 0, -4);
	if (!array_key_exists($sVariableName, $aDataSources))
	{
		continue;
	}
	
	$aDataSourceConfig = $aDataSources[$sVariableName];
	
	echo 'Reading ' . $sDataFile . '...'; 
	$aData = file($sDataDir . $sDataFile);
	unset($aData[0]);
	
	if (array_key_exists('multi_row', $aDataSourceConfig)
	&& $aDataSourceConfig['multi_row'] === true)
	{
		$aAggrigatedData = array();
		
		foreach ($aData as $sDataItem)
		{
			if (trim($sDataItem) == '')
			{
				break;
			}			
			
			$aDataItemArray = explode($aDataSourceConfig['delimiter'], $sDataItem);
			$aDataItemArray = str_replace( array('\'', '"'), '', $aDataItemArray);
			
			// does the country exist?
			if (!array_key_exists($aDataItemArray[$aDataSourceConfig['format'][0]], $aAggrigatedData))
			{
				$aAggrigatedData[$aDataItemArray[$aDataSourceConfig['format'][0]]] = array();
			}
		
			if (!array_key_exists($aDataItemArray[$aDataSourceConfig['format'][1]], $aAggrigatedData[$aDataItemArray[$aDataSourceConfig['format'][0]]]))
			{
				$aAggrigatedData[$aDataItemArray[$aDataSourceConfig['format'][0]]][$aDataItemArray[$aDataSourceConfig['format'][1]]] = $aDataItemArray[$aDataSourceConfig['format'][2]];
			}
			else
			{
				$aAggrigatedData[$aDataItemArray[$aDataSourceConfig['format'][0]]][$aDataItemArray[$aDataSourceConfig['format'][1]]] += $aDataItemArray[$aDataSourceConfig['format'][2]];
			}
		}
		
		foreach ($aAggrigatedData as $sCountry => $aCountryData)
		{
			if (!in_array($sCountry, $aSkipCountries))
			{
				if (array_key_exists($sCountry, $aCountryAliases))
				{
					$sCountry = $aCountryAliases[$sCountry];
				}
				
				foreach ($aCountryData as $iYear => $mCountryYearData)
				{
					$sCC = $aCountryCodes[$sCountry];
					
					$oDataItem = new DataItem(	$sCC,
												$iYear,
												$sVariableName,
												$mCountryYearData);
				
					$oDataItem->save();
				}
			}
		}
		
	}
	else 
	{
		foreach ($aData as $sDataItem)
		{
			if (trim($sDataItem) == '')
			{
				break;
			}

			$aDataItemArray = explode($aDataSourceConfig['delimiter'], $sDataItem);
			$aDataItemArray = str_replace( array('\'', '"'), '', $aDataItemArray);
			
			if (!in_array($aDataItemArray[$aDataSourceConfig['format'][0]], $aSkipCountries))
			{
				if (array_key_exists($aDataItemArray[$aDataSourceConfig['format'][0]], $aCountryAliases))
				{
					$aDataItemArray[$aDataSourceConfig['format'][0]] = $aCountryAliases[$aDataItemArray[$aDataSourceConfig['format'][0]]];
				}				
				
				$sCC = $aCountryCodes[$aDataItemArray[$aDataSourceConfig['format'][0]]];
				
				$oDataItem = new DataItem(	$sCC,
											$aDataItemArray[$aDataSourceConfig['format'][1]],
											$sVariableName,
											$aDataItemArray[$aDataSourceConfig['format'][2]]);
				
				$oDataItem->save();
			}
		}
	}
	
	echo " done!\n";
}



