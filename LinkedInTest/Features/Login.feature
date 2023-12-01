Feature: Login      
user logs in with valid credentials(username,password)
the home page will load after successful login

@positive
Scenario: Login with valid credentials
	Given User will be on the login page
	When User will enter username
	And User will enter password
	And User will click on login button
	Then User will be redirected to home page

@negative
Scenario: Login with Invalid credentials
	Given User will be on the login page
	When User will enter username
	And User will enter password
	And User will click on login button
	Then Error message for Password Length should be thrown