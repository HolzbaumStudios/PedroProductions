
		<?php
						   
			   //-------Create Users------------
			function CreateUser(){
				//Connect DB
				include('../db_php/connect_db.php');

				
				$username = $_POST["username"];
				$password = $_POST["password"];
				$password2 = $_POST["password2"];
				
				if($username == ""){
					
				}else{
					//Check username
					$query = 'SELECT COUNT(*) FROM tbl_user WHERE `username` = ?'; //Check if there is a user with this username
					$ergebnis = $db->prepare( $query );
					$ergebnis->bind_param( 's', $username);
					$ergebnis->execute();
					// Ergebnis an Variablen binden
					$ergebnis->bind_result( $result);
					//Schreibe Daten in Variabel
					$ergebnis->fetch();
					$ergebnis->close(); //Close DBConnection again

					
					if($result > 0) //If user alread exists..
					{	
						
						//What happens, when the username already exists
						
					}else{ //If user does not exist
						
						if(strlen($password) >= 5){ //Überprüft die Länge des Passworts und ob eine Zahl verwendet wird
						
							if($password == $password2)
							{
								$Salt = md5(rand(0,1000));
								$algo = '6';
								
								$rounds = rand(4950,5100);
								
								$CryptSalt = '$' . $algo . '$rounds=' . $rounds. '$' . $Salt ;		
								
								$HashedPassword = crypt($password, $CryptSalt);
								
								//USER erstellen
								$query = 'INSERT INTO tbl_user (username,password,salt) VALUES (?,?,?)';
								$ergebnis = $db->prepare( $query );
								$ergebnis->bind_param( 'sss', $username, $HashedPassword, $CryptSalt);
								$ergebnis->execute(); //Führt das Statement aus
								$ergebnis->close(); //Close DBConnection again
							
							}
							else
							{
								
								//What happens when the passwords don't match
								
							}
						}else{
							//What happebs when the password doesn't meet the complexity requirements
						}
					}
					
				}
			//END CREATE USERS------------------------------------
			}
		?>
		
		

