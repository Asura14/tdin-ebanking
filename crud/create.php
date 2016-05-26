<?php 
	
	require 'database.php';

	if ( !empty($_POST)) {
		// keep track validation errors
		$nameError = null;
		$emailError = null;
		$mobileError = null;
		
		// keep track post values
		$company = $_POST['company'];
		$type = $_POST['type'];
		$quantity = $_POST['quantity'];
		$order = array();
		$order['order'] = array(
			'Id'			=>	1,
			'Client_id'		=> 	1,
			'Company_id'	=> $company,
			'State'			=>	'unexecuted',
			'Value'			=>	30,
			'Type'			=>	$type,
			'Quantity'		=>	$quantity,
			'Creation_Date'	=>	'2012-04-23',
			'Execution_Date'=>	''	
			);

		$order['comp'] = array(
			'Id'	=>	$company,
			'Name'	=>	'Noproblem',
			'CurrentStockPrice'	=> 20
			);

		$get_url = 'localhost:8000/PostOrder';
		$headers = array (
			'Content-Type: application/json; charset=utf-8',
	    	'Accept: application/json; charset=utf-8',
	    	'User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:7.0.1) Gecko/20100101 Firefox/7.0.1'
	    	);
	    $response = curlWrap($get_url,json_encode($order),'POST',$headers);
	    echo $response;
	    if($response == "success"){
	    	header("Location: index.php");
	    }
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
		    			<h3>Buy Stock</h3>
		    		</div>
    		
	    			<form class="form-horizontal" action="create.php" method="post">
					  <div class="control-group ">
					    <label class="control-label">Company</label>
					    <div class="controls">
						      <select class="form-control" name="company" id="sel1">
						        <option value="1">Microsoft</option>
						        <option value="2">Apple</option>
						        <option value="3">Google</option>
						      </select>
					    </div>
					  </div>
					  <div class="control-group">
					    <label class="control-label">Quantity</label>
					    <div class="controls">
					      	<input name="quantity" type="number" placeholder="Quantity" min ="1">
					    </div>
					  </div>
					  <div class="control-group ">
					    <label class="control-label">Type</label>
					    <div class="controls">
						      <select class="form-control" name="type" id="sel2">
						        <option value="buy">Buy</option>
						        <option value="sell">Sell</option>
						      </select>
					    </div>
					  </div>
					  <div class="form-actions">
						  <button type="submit" class="btn btn-success">Create</button>
						  <a class="btn" href="index.php">Back</a>
						</div>
					</form>
				</div>
				
    </div> <!-- /container -->
  </body>
</html>