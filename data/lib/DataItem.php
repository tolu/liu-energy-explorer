<?php

class DataItem 
{
	private $sCountry;
	private $iYear;
	private $sVariable;
	private $mValue;
	
	
	public function __construct($a_sCountry, $a_iYear, $a_sVariable, $a_mValue)
	{
		$this->sCountry = $a_sCountry;
		$this->iYear = (int) $a_iYear;
		$this->sVariable = $a_sVariable;
		$this->mValue = $a_mValue;
	}
	
	public function save()
	{
		DBConnection::query('INSERT INTO `source_data` (`country`, `year`, `variablename`, `value`) values("' 
		. DBConnection::escString($this->sCountry) . '", ' . $this->iYear . ', "'
		. DBConnection::escString($this->sVariable) . '", "'
		. DBConnection::escString($this->mValue) . '")', false);
	}
}