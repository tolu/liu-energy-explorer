<?php

class DataItemPeer 
{
	public static function getAllCountries()
	{
		$aAllCountriesTmp = DBConnection::query('SELECT country FROM source_data GROUP BY country ORDER BY country');
		
		$aAllCountries = array();
		foreach ($aAllCountriesTmp as $aCountry)
		{
			$aAllCountries[] = $aCountry['country'];
		}
		
		return $aAllCountries;		
	}	

	public static function getAllYears()
	{
		$aAllTmp = DBConnection::query('SELECT year FROM source_data GROUP BY year ORDER BY year ASC');
		
		$aAll = array();
		foreach ($aAllTmp as $aYear)
		{
			$aAll[] = (int) $aYear['year'];
		}
		
		return $aAll;		
	}	
	
	public static function getAllVariables()
	{
		$aAllTmp = DBConnection::query('SELECT variablename FROM source_data GROUP BY variablename ORDER BY variablename');
		
		$aAll = array();
		foreach ($aAllTmp as $aVar)
		{
			$aAll[] = $aVar['variablename'];
		}
		
		return $aAll;		
	}
	
	
	public static function getDataByCountryCodeAndYear($a_sCountry, $a_iYear)
	{
		$aDataTmp = DBConnection::query('SELECT `variablename`, `value` FROM source_data WHERE `country` = "' . $a_sCountry . '" AND `year` = ' . $a_iYear . ' ORDER BY `variablename`');
		
		$aData = array();
		foreach ($aDataTmp as $aEntry)
		{
			$aData[$aEntry['variablename']] = $aEntry['value'];
		}
		
		return $aData;	
	}
	
}