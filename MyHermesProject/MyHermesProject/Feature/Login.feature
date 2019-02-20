Feature: Login
	In order to login to my account
	As a User
	I want to be able to login to my account when I provide valid credentials

@Login
Scenario Outline: Login Test
	Given I navigate to myHermes site
	When I choose to login with '<Credential>' user '<Email address>' details
	Then I should see '<Page title>' page
	And I should see '<Message>' for user with '<Credential>'
	Scenarios:
	| Credential | Email address         | Page title                        | Message                                                   |
	| Valid      | Osifo12@yahoo.com     | myHermes - Home page for customer | All your parcel needs in one place                        |
	| Invalid    | InvalidUser@yahoo.com | myHermes - Sign in                | Sorry, we don't recognise that email address and password |

Scenario Outline: Login Test 2
	Given I navigate to myHermes site
	When I choose to login with 
	| SiteUsersEmailAddress |
	| <Email address>     | 
	Then I should see '<Page title>' page
	Scenarios:
	| Email address         | Page title                        | 
	| Osifo12@yahoo.com     | myHermes - Home page for customer |
	| InvalidUser@yahoo.com | myHermes - Sign in                |


	
