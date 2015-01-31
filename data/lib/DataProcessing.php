<?php

class DataProcessing 
{
	private static $oInstance;
	
	const EMPTY_CELL_VALUE = '-1';
	
	public function process($a_aDataArray, $a_aAllVars)
	{	
		if (!(self::$oInstance instanceof DataProcessing))
		{
			self::$oInstance = new DataProcessing();
		}
				
		$aProcessedData = array();

		foreach ($a_aAllVars as $sVarName => $sVarLabel)
		{
			if (array_key_exists($sVarName, $a_aDataArray))
			{
				$aProcessedData[$sVarName] = self::$oInstance->processVariable($sVarName, $a_aDataArray);
			}
			else
			{
				$aProcessedData[$sVarName] = self::EMPTY_CELL_VALUE;
			}
		}

		//var_dump(__METHOD__, $a_aDataArray, $aProcessedData);
				
		return $aProcessedData;
	}
	
	private function processVariable($a_sVarName, $a_aDataArray)
	{
		$aMethodName = 'process' . str_replace(" ", "", ucwords(str_replace("_", " ", $a_sVarName)));
		
		if (method_exists(self::$oInstance, $aMethodName))
		{
			return self::$oInstance->$aMethodName($a_aDataArray);
		}
		
		return $a_aDataArray[$a_sVarName];
	}
	
	/*
		'energy_use'
		'electric_energy'
		'computers' 
		'internet_users'
		'employment_rate'
		'unemployment_rate' 
		'infant_mortality'
		'pop_below_poverty'
		'pop_urban'
		'export'
		'import' 
		'gpd_per_capita' 
		'greenhouse_gas'
		'gdp_national'
		'gdp'
		'population'
		
		
		'electric_consumption', 
		'energy_use_per_capita',
		'export_percent_gdp',
		'import_percent_gdp',
		'life_expectancy',
		'child_mortality_rate',
		'surface_area',
		'gdp_anual_growth',
		'pop_total',		
	*/	
	
	private function processImport($a_aDataArray)
	{
		if (array_key_exists('gdp_national', $a_aDataArray) && $a_aDataArray['gdp_national'] != 0)
		{
			return $a_aDataArray['import'] / $a_aDataArray['gdp_national'];
		}
		
		return self::EMPTY_CELL_VALUE;
	}
	
	private function processExport($a_aDataArray)
	{
		if (array_key_exists('gdp_national', $a_aDataArray) && $a_aDataArray['gdp_national'] != 0)
		{
			return $a_aDataArray['export'] / $a_aDataArray['gdp_national'];
		}
		
		return self::EMPTY_CELL_VALUE;
	}
	
	private function processGreenhouseGas($a_aDataArray)
	{
		//return $a_aDataArray['greenhouse_gas'];
		
		if (array_key_exists('pop_total', $a_aDataArray) && $a_aDataArray['pop_total'] != 0)
		{
			return $a_aDataArray['greenhouse_gas'] / $a_aDataArray['pop_total'];
		}
		
		
		return self::EMPTY_CELL_VALUE;
	}

	private function processElectricEnergy($a_aDataArray)
	{
		return $a_aDataArray['electric_energy'];
		
		if (array_key_exists('population', $a_aDataArray) && $a_aDataArray['population'] != 0)
		{
			return $a_aDataArray['electric_energy'] * 1000 / $a_aDataArray['population'];
		}
		
		return self::EMPTY_CELL_VALUE;
	}
	
	
}



