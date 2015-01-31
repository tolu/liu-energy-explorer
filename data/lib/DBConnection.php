<?php

class DBConnection {

	private static $oDBC;

	const DB_HOST = 'localhost';
	//const DB_HOST = 'spike';
	//const DB_PORT = '3306';
	const DB_USER = 'tnm048_user';
	const DB_PASSW = 'infoviz';
	const DB_DATABASE = 'tnm048_project';

	public static function query($sSQL, $bReturnArray = true)
	{
		//echo $sSQL . "\n";
		//exit(__FILE__);

		if ($bReturnArray)
		{
			$result = array();
			$queryResult = mysql_query($sSQL, DBConnection::$oDBC);
			
			while (($aRow = mysql_fetch_assoc($queryResult)))
			{
				$result[] = $aRow;
			}
		}
		else
		{
			$result = mysql_query($sSQL, DBConnection::$oDBC);
		}

		DBConnection::checkError();
		return $result;
	}

	public static function insetId()
	{
		$iId = mysql_insert_id(DBConnection::$oDBC);
		DBConnection::checkError();

		return $iId;
	}

	public static function escString($sString)
	{
		return mysql_real_escape_string($sString, DBConnection::$oDBC);
	}

	public static function init()
	{
		DBConnection::$oDBC = mysql_connect(DBConnection::DB_HOST, DBConnection::DB_USER, DBConnection::DB_PASSW);
		mysql_select_db(DBConnection::DB_DATABASE, DBConnection::$oDBC);
		DBConnection::checkError();

	}

	private function checkError()
	{
		if (mysql_errno(DBConnection::$oDBC) != 0)
		{
			throw new DBException(mysql_error(DBConnection::$oDBC), mysql_errno(DBConnection::$oDBC));
		}
	}
}


class DBException extends Exception {

}


