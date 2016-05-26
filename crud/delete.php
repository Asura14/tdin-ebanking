<?php 
	require 'database.php';
	$id = 0;
	
	if ( !empty($_GET['id'])) {
		$id = $_REQUEST['id'];
	}
	
	if ( !empty($_POST)) {
		// keep track post values
		$id = $_POST['id'];
		$order['order'] = array(
			'Id'			=>	$_POST['id'],
			'Client_id'		=> 	1,
			'Company_id'	=> 	1,
			'State'			=>	'unexecuted',
			'Value'			=>	30,
			'Type'			=>	'sell',
			'Quantity'		=>	30,
			'Creation_Date'	=>	'2012-04-23',
			'Execution_Date'=>	''	
			);
		$get_url = 'localhost:8000/DeleteOrder';
		$headers = array (
			'Content-Type: application/json; charset=utf-8',
	    	'Accept: application/json; charset=utf-8',
	    	'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
	    	);
	    $response = curlWrap($get_url,json_encode($order),'DELETE',$headers);
		header("Location: index.php");
		
	} 
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <link   href="css/bootstrap.min.css" rel="stylesheet">
    <script src="js/bootstrap.min.js"></script>
</head>

<body>
    <div class="container">
    
    			<div class="span10 offset1">
    				<div class="row">
		    			<h3>Delete an Order</h3>
		    		</div>
		    		
	    			<form class="form-horizontal" action="delete.php" method="post">
	    			  <input type="hidden" name="id" value="<?php echo $id;?>"/>
					  <p class="alert alert-error">Are you sure to delete ?</p>
					  <div class="form-actions">
						  <button type="submit" class="btn btn-danger">Yes</button>
						  <a class="btn" href="index.php">No</a>
						</div>
					</form>
				</div>
				
    </div> <!-- /container -->
  </body>
</html>