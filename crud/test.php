<?php
include 'database.php';
					   $get_url = 'localhost:8000/GetCompany?id=1';
					   $headers = array (
					    	'Content-Type: application/json; charset=utf-8',
					    	'Accept: application/json; charset=utf-8',
					    	'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
						);
					   $headers = array();
					   $response = curlWrap($get_url,'','GET',$headers);
					   print_r(json_decode($response, true));
					   echo json_decode($response, true)['Name'];
?>