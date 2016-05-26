<?php
function curlWrap($url, $json, $action, $headers)
			{
				$ch			=			curl_init();
		
				curl_setopt($ch, CURLOPT_URL, $url);

				switch($action){
					case "POST":
						curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "POST");
						curl_setopt($ch, CURLOPT_POSTFIELDS, $json);
						break;
					case "GET":
						curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "GET");
						break;
					case "PUT":
						curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "PUT");
						curl_setopt($ch, CURLOPT_POSTFIELDS, $json);
						break;
					case "DELETE":
						curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "DELETE");
						curl_setopt($ch, CURLOPT_POSTFIELDS, $json);
						break;
					default:
						break;
					}
		
					curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
					curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
					curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

					$output = curl_exec($ch);

					curl_close($ch);
					return $output;
			}
?>