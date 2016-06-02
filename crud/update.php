<?php 
	
	require 'database.php';
	session_start();
	$id = null;
	$type = 'sell';
	if ( !empty($_GET['id'])) {
		$id = $_REQUEST['id'];
		$type = $_REQUEST['type'];
	}
	
	if ( null==$id ) {
		header("Location: dashboard.php");
	}
	
	if ( !empty($_POST)) {
		// update data
			$order['order'] = array(
			'Id'			=>	$id,
			'Client_id'		=> 	1,
			'Company_id'	=> 	1,
			'State'			=>	'unexecuted',
			'Value'			=>	30,
			'Type'			=>	$_POST['type'],
			'Quantity'		=>	30,
			'Creation_Date'	=>	'2012-04-23',
			'Execution_Date'=>	''	
			);
		$get_url = 'localhost:8000/UpdateOrder';
		$headers = array (
			'Content-Type: application/json; charset=utf-8',
	    	'Accept: application/json; charset=utf-8',
	    	'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
	    	);
	    $response = curlWrap($get_url,json_encode($order),'PUT',$headers);
		header("Location: dashboard.php");

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
		    			<h3>Edit an Order</h3>
		    		</div>
    		
	    			<form class="form-horizontal" action="update.php?id=<?php echo $id?>" method="post">
					  <div class="control-group ">
					    <label class="control-label">Type</label>
					    <div class="controls">
						      <select class="form-control" name="type" id="sel2">
						        <option <?php if($type == 'buy') echo "selected = 'selected'"?> value="buy">Buy</option>
						        <option <?php if($type == 'sell') echo "selected = 'selected'"?>value="sell">Sell</option>
						      </select>
					    </div>
					  <div class="form-actions">
						  <button type="submit" class="btn btn-success">Update</button>
						  <a class="btn" href="index.php">Back</a>
						</div>
					</form>
				</div>
				
    </div> <!-- /container -->
  </body>
</html>