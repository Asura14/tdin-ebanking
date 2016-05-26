<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <link   href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/bootstrap.min.js"></script>
</head>

<body>
    <div class="container">
    		<div class="row">
    			<h3>PHP CRUD Grid</h3>
    		</div>
			<div class="row">
				<p>
					<a href="create.php" class="btn btn-success">Create</a>
				</p>
				
				<table class="table table-striped table-bordered">
		              <thead>
		                <tr>
		                  <th>Type</th>
		                  <th>State</th>
		                  <th>Quantity</th>
		                  <th>Value</th>
		                  <th>Creation Date</th>
		                  <th>Execution Date</th>
		                </tr>
		              </thead>
		              <tbody>
		              <?php 
					   include 'database.php';
					   $get_url = 'localhost:8000/GetClientHistory?id=1';
					   $headers = array (
					    	'Content-Type: application/json; charset=utf-8',
					    	'Accept: application/json; charset=utf-8',
					    	'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
						);
					   $response = curlWrap($get_url,'','GET',$headers);

	 				   foreach (json_decode($response,true) as $row) {
						   		echo '<tr>';
							   	echo '<td>'. $row['Type'] . '</td>';
							   	echo '<td>'. $row['State'] . '</td>';
							   	echo '<td>'. $row['Quantity'] . '</td>';
							   	echo '<td>'. $row['Value'] . '</td>';
							   	//DateStuff
							   	$date_string = $row['Creation_date'];
								preg_match( '/([\d]{10})/', $date_string, $matches ); // gets just the first 9 digits in that string
							   	echo '<td>'. date( 'Y-m-d', $matches[0] ) . '</td>';
							   	$date_string = $row['Execution_date'];
								preg_match( '/([\d]{10})/', $date_string, $matches );
								$e_date = date( 'Y-m-d', $matches[0] );
								if($e_date == '2030-10-19'){
									echo '<td> No Info </td>';
								}
								else {
									echo '<td>'. date( 'Y-m-d', $matches[0] ) . '</td>';
								}
							   	echo '<td>';
							   	if($row['State'] == 'unexecuted'){
								   	echo '<a class="btn btn-success" href="update.php?id='.$row['Id'].'&type='.$row['Type'].'">Edit</a>';
								   	echo '&nbsp;';
								   	echo '<a class="btn btn-danger" href="delete.php?id='.$row['Id'].'">Delete</a>';
							   	}
							   	echo '</td>';
							   	echo '</tr>';
					   }
					  ?>
				      </tbody>
	            </table>
    	</div>
    </div> <!-- /container -->
  </body>
</html>