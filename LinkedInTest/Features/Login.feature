Feature: Login      
user logs in with valid credentials(username,password)
the home page will load after successful login

Background: 
  Given User will be on the login page


@positive
Scenario: Login with valid credentials	
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then User will be redirected to home page

	Examples:
     | UserName      | Password   |
     | abc@gmail.com | 123456     |
     | xyz@gmail.com | 456789     |

@negative
Scenario: Login with Invalid credentials
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then Error message for Password Length should be thrown

	Examples:
     | UserName      | Password |
     | def@gmail.com | 444     |
     | xyz@gmail.com | 438     |

@regression
Scenario: Password is being visible by user in Login Page
	When User will enter password '<Password>'
	And User will click show link on Password box
	Then Password should be visible to user

	Examples:
     | Password |
     | 1111     |

@regression
Scenario: Password is being hide by user in Login page
	When User will enter password '<Password>'
	And User will click show link on Password box
	And User will click hide link on Password box
	Then Password should be hide to user

	Examples:
     | Password |
     | 2222     |