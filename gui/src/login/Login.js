import { useRef, useState } from 'react';
import './Login.css';
import { useNavigate } from "react-router-dom"
import * as aj from "../ajax";


function Login() {
	const username = useRef(null);
	const password = useRef(null);
	const usernameR = useRef(null);
	const passwordR = useRef(null);
	const password2R = useRef(null);
	let history = useNavigate();

	const handleSwitchToLogin = () => {
		closeAlert();
		document.getElementById("registerCan").style.visibility = "collapse";

		var divRegisterCanvas = document.getElementById("registerCan");
		document.getElementById("LoginCan").style.left = "0%";
		var intervalID = window.setInterval(myCallback, 10);
		var startLeft = 40;
		function myCallback() {
			if (startLeft == 30) {
				document.getElementById("ChangeToLoginCan").style.visibility = "collapse";
				document.getElementById("ChangeToRegisterCan").style.visibility = "visible";
			}
			if (startLeft > 0) {
				startLeft -= 2;
				divRegisterCanvas.style.left = startLeft.toString() + "%";
			}
			else {
				document.getElementById("registerCan").style.visibility = "collapse";
				document.querySelector("#registerCan > button.btn-grad").style.display = "none";
				document.getElementById("LoginCan").style.visibility = "visible";
				clearInterval(intervalID);
			}
		}
	}

	const handleSwitchToRegister = () => {
		closeAlert();
		var divRegisterCanvas = document.getElementById("LoginCan");
		document.getElementById("registerCan").style.left = "40%";
		var intervalID = window.setInterval(myCallback, 10);
		var startLeft = 0;
		function myCallback() {
			if (startLeft == 10) {
				document.getElementById("ChangeToRegisterCan").style.visibility = "collapse";
				document.getElementById("ChangeToLoginCan").style.visibility = "visible";
			}
			if (startLeft < 40) {
				startLeft += 2;
				divRegisterCanvas.style.left = startLeft.toString() + "%";
			}
			else {
				document.getElementById("LoginCan").style.visibility = "collapse";
				document.querySelector("#registerCan > button.btn-grad").style.display = "inline-block";
				document.getElementById("registerCan").style.visibility = "visible";
				clearInterval(intervalID);
			}
		}
	}

	const handleLogin = (uname, password) => {
		var UserName = username.current.value;
		var Password = password.current.value;
		aj.login(UserName,Password, history);	
	}

	const handleRegister = (usernameR, passwordR, password2R) => {
		var UsernameR = usernameR.current.value;
		var PasswordR = passwordR.current.value;
		var Password2R = password2R.current.value;
		if (UsernameR == "" || PasswordR == "" || Password2R == "" ) {
			document.getElementById('alert').style.visibility = "collapse";
			document.getElementById('alert').innerHTML = "Something is missing";
			document.getElementById('alert').style.visibility = "visible";	
			return;
		}

		if (PasswordR != Password2R) {
			document.getElementById('alert').style.visibility = "collapse";
			document.getElementById('alert').innerHTML = "The passwords do not match:(";
			document.getElementById('alert').style.visibility = "visible";

			document.getElementById("passwordR").value = "";
			document.getElementById("password2R").value = "";
			return;
		}

		var passw = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{3,}/;
		if(!PasswordR.match(passw)) {
			document.getElementById('alert').style.visibility = "collapse";
			document.getElementById('alert').innerHTML = "Password need to contain at least one numeric digit, one uppercase and one lowercase letter";
			document.getElementById('alert').style.visibility = "visible";	
			return;
		}
		aj.register(UsernameR,PasswordR,history);

	}

	const closeAlert = function() {
		document.getElementById('alert').style.visibility = "collapse";
	}


	return (
		<div>
			<img className='background' src="Images/backgroundLogin.jpg" />
			<img className='mainCanvas' src="Images/switchBackground.jpg" />
            
			<div className="mainCanvas"> */}
				<div id='LoginCan' className='LoginCanvas'>
					<h1 className='text2'>Sign In</h1>
					<br />
					<input onClick={() => { closeAlert() }} ref={username} className='input' type="uname" placeholder='Username' required />
					<br /><br />
					<input onClick={() => { closeAlert() }} ref={password} className='input' type="password" placeholder='Password' required />

					<button  onClick={() => { handleLogin(username, password) }} className='btn-grad'>Login</button>

				</div>


				<div id='ChangeToRegisterCan' className='ChangeToRegisterCanvas'>
					<h1 className='textSwitch'>New Here?</h1>
					<br />
					<em className='textSwitch3'>Enter your personal details and let's get started!</em>
					<br />
					<button onClick={() => { handleSwitchToRegister() }} className='loginBtn'>Sign Up</button>
				</div>


				<div id='registerCan' className='RegisterCanvas'>
					<h1 className='text'>Registration</h1>
					<br />

					<input onClick={() => { closeAlert() }} ref={usernameR} className='input' id="usernameR" placeholder='Username' required />
					<br /><br />
					<input onClick={() => { closeAlert() }} ref={passwordR} className='input' id="passwordR" type="password" placeholder='Password' required />
					<br /><br />
					<input onClick={() => { closeAlert() }} ref={password2R} className='input' id="password2R" type="password" placeholder='Re-enter password' required />
					<button onClick={() => { handleRegister(usernameR, passwordR, password2R) }} className='btn-grad'>Sign Up</button>
				</div>
				<div id='ChangeToLoginCan' className='ChangeToLoginCanvas'>
					<h1 className='textSwitch'>Welcome Back!</h1>
					<br />
					<em className='textSwitch2'>already have an acount?</em>
					<br />
					<button id='hey' onClick={() => { handleSwitchToLogin() }} className='loginBtn'>Sign In</button>
				</div>
				<div className="alert alert-warning" role="alert" id='alert'/>
				<div></div>

			</div>
		</div>
	);
}

export default Login;
