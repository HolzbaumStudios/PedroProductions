<HTML>
	<head>
		<title>Digital Ninja - SignIn</title>
		<link rel="stylesheet" href="../css/mainstyle.css" type="text/css"> <!--CSS Einbindung-->
		<link rel="stylesheet" href="../css/login.css" type="text/css">
		
		<?php
			session_start(); //starts the session
			
			$error;
			if(ISSET($_GET["error"])){
				$error = $_GET["error"];
			}
			//Falls Account freigeschaltet wird
			if(ISSET($_GET["name"]) && ISSET($_GET["salt"])){
				ActivateAccount();
			}
			
			if(ISSET($_GET["link"])){
				$_SESSION["returnLink"] = $_GET["link"];
			}
		
			if($_SERVER['REQUEST_METHOD']=='POST') //Checks if the submit button is clicked
			{
				if(ISSET($_POST["loginButton"])){ //If create submit button is pressed
					LogIn();
				}
			}
			
			function ActivateAccount(){
				$username = $_GET["name"];
				$salt = $_GET["salt"];
				
				include('../db_php/connect_db.php');
				
				$query = 'SELECT COUNT(username) FROM tbl_user WHERE `username`=? AND `salt`=?'; //Check if there is a user with this username
				$ergebnis = $db->prepare( $query );
				$ergebnis->bind_param( 'ss', $username, $salt);
				$ergebnis->execute();
				// Ergebnis an Variablen binden
				$ergebnis->bind_result( $result_count_username);
				//Schreibe Daten in Variabel
				$ergebnis->fetch();
				$ergebnis->close(); //Close DBConnection again
				
				if ($result_count_username > 0){
					$query = 'UPDATE tbl_user SET `active`=1 WHERE `username`=?'; //Check if there is a user with this username
					$ergebnis = $db->prepare( $query );
					$ergebnis->bind_param( 's', $username);
					$ergebnis->execute();
					
					$GLOBALS["error"] = "Der Benutzer ". $username ." wurde freigeschaltet. Sie k&ouml;nnen sich jetzt anmelden.";
				}
				
				$ergebnis->close(); //Close DBConnection again
				
			}
			
			function LogIn()
			{
				//Connect DB
				include('../db_php/connect_db.php');
				
				$username = $_POST["username"];
				$password = $_POST["password"];
				
				
				$query = 'SELECT COUNT(*) FROM tbl_user WHERE `username`=? OR `email`=?'; //Check if there is a user with this username
				$ergebnis = $db->prepare( $query );
				$ergebnis->bind_param( 'ss', $username, $username);
				$ergebnis->execute();
				// Ergebnis an Variablen binden
				$ergebnis->bind_result( $result_count_username);
				//Schreibe Daten in Variabel
				$ergebnis->fetch();
				$ergebnis->close(); //Close DBConnection again
				

				if($result_count_username > 0){ //Wenn User existiert
					//Check if user is active
					$query = 'SELECT username,password,salt,active,admin FROM tbl_user WHERE `username`=? OR `email`=?';
					$ergebnis = $db->prepare( $query );
					$ergebnis->bind_param( 'ss', $username, $username);
					$ergebnis->execute();
					// Ergebnis an Variablen binden
					$ergebnis->bind_result( $result_username,$result_password,$result_salt,$result_active,$_SESSION['isAdmin']);
					//Schreibe Daten in Variabel
					$ergebnis->fetch();
					
					$ergebnis->close();
					
					if($result_active == 1)
					{
						//CHECK FOR PASSWORD HERE!!!!!!!!!!!
						//Hash the password with the salt of the data row
						$hashedPassword = crypt($password, $result_salt);
					
						if($hashedPassword == $result_password)
						{
							$_SESSION['userSession'] = $result_username;
							if(ISSET($_SESSION["returnLink"]))
							{
								header ('Location:'. $_SESSION["returnLink"]);
								$_SESSION["returnLink"] = NULL;
							}else{
								header( 'Location: ../index.php' ) ;
							}
						}else{
							$GLOBALS["error"] = "User und Passwort stimmen nicht &uuml;berein!";
						}
					
						
					}else{
						$GLOBALS["error"] = "User wurde noch nicht aktiviert!";
					}
					
					
					
				}else{
					$GLOBALS["error"] = "User existiert nicht!";
				}
				
				
			}
		
			
		?>
	</head>
	
	<body>
		<!-- TOP DIV-->
		<?php
			include('../main/header.php');
		?>
		<!-- END TOP DIV -->
		
				
		<!-- Section1 DIV-->
		<div class="sectiondiv" style="background-color:#E5E5E5">
			<!-- SIGN IN DIV-->
				&nbsp;
				<div class="signin">
					<form name="loginform" method="POST" action="login.php" autocomplete="on"> <!-- Login-Form-->
						<label for="username">BENUTZERNAME ODER EMAIL</label> <br>
						<input type="text" name="username" id="username"> <br>
						<label for="password">PASSWORT</label>	<br>
						<input type="password" name="password" id="password" autocomplete="off"> <br>
						<p><a href="reset.php" >Haben Sie Ihr Passwort vergessen?</a></p> <br>
						<button type="submit" id="loginButton" name="loginButton">ANMELDEN</button>
					</form>
				</div>
			<!-- END SIGN IN DIV-->
			
			<!--Error DIV-->
			<?php
				if(ISSET($error)){
					echo('
							<br>
							<div class="error">
								<p>' .$error. '</p>
							</div>
					');
				}
			?>
		</div>
		<!-- END SECTION DIV -->
		
		
		
		
		<!-- BOTTOM DIV-->
		<?php
			include('../main/footer.html');
		?>
		<!-- END BOTTOM DIV -->
	</body>
</HTML>