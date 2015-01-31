<?php

class ExcelPointer  
{
	private $iRow = 1;
	private $sCollumn = 0;
	
	private $aCollumnNames = array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U');

	public function getPointer()
	{
		return (string) $this->aCollumnNames[$this->sCollumn] . $this->iRow;
	}
	
	public function getColNumber()
	{
		return $this->sCollumn;
	}
	
	public function rowStep()
	{
		$this->iRow++;
	}	
	
	public function colStep()
	{
		$this->sCollumn++;
	}
	
	public function resetColPointer()
	{
		$this->sCollumn = 0;
	}
	
}