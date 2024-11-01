Feature: TFL

TfL website – Journey Planner Widget

Scenario: Plan a valid journey
	Given customer is on plan a journey planner widget via TfL website
	When customer plans a journey from 'Leicester Square' to 'Covent Garden'
	Then the result page should display cycling time as '1mins' and walking time as '6mins'

Scenario: Routes with least walking option
	Given customer has planned a journey from 'Leicester Square' to 'Covent Garden'
	When customer updates journey to routes with least walking
	Then the result page should display journey time as '11mins' 

Scenario: Complete access information
	Given customer has updated routes with least walking between 'Leicester Square' and 'Covent Garden'
	When customer clicks on view details button
	Then access information should display 

Scenario: Customer inputs invalid journey
	Given customer is on plan a journey widget
	When customer plans an invalid journey
	Then error message should be displayed on journey results page as "Sorry, we can't find a journey matching your criteria"

Scenario: Customer enters no locations
	Given customer is on plan a journey widget
	When customer enters no locations
	Then error message should be displayed for from field as 'The From field is required.'
	And error message should be displayed for to field as 'The To field is required.'

	
## Additional Scenarios For Functional Requirements	

@ignore
Scenario: Customer able to add to favorites for future quick access for a planned journey
	Given customer is on plan a journey widget
	When customer navigates to click on 'My Journeys'
	And Plan a journey link with 'add to favourite for quick access in future' text is displayed
	And customer clicks on Plan a journey
	And customer populates 'From place or address' field
	And customer populates 'To place or address' field
	And customer click on Plan my journey botton
	Then the Journey results should be displayed with Add favorites icon
	And customer should be able to click on the favourites icon
	And Faourite journey Done page with icon should be displayed with My Places
	And customer able to click the favourite star icon to change from grey to white

	@ignore
Scenario: Customer able to click Recents tab in order to view recent planned journeys
	Given customer is on plan a journey widget
	When customer navigates to click on 'Recents Tab'
	Then recently planned journey(s) should be displayed

	@ignore
Scenario: Customer is able to click on Live arrivals icon or tab or link
	Given customer is on plan a widget
	When a customer navigates to click on Live arrivals
	Then Stations, stops & piers should be displayed
	And Tube and rails should be displayed
	And Buses should be displayed
	And River buses and cruises should be displayed

	@ignore
Scenario: Customer is able to click on the Maps icon or tab or link
	Given customer is on plan a journey widget
	When a customer navigates to click on the Maps icon
	Then Tube and rails maps to help you get around should be displayed
	And Bus maps available to view should be displayed
	And Bus maps available to download should be displayed
	And Cycle maps with routes should be displayed
	And Cycle docking stations should be displayed 
	And River maps available to view should be displayed
	And River maps available to download should be displayed
	And congestion maps available to view should be displayed
	And congestion maps available to download should be displayed
	And Ultra low Emission Zone maps should be displayed
	And Ultra Low Emission Zone available to downlaod should be displayed
	And Red routes map interactive available to view should be displayed
	And Oyster Ticket stop map to find your nearest Oyter shop should be displayed
	And TfL Go our Live Tube map app that helps plan travel on the move should be displayed
	And Walking maps with routes and descriptions should be displayed
	And Accessible maps and guides with audio of main maps should be displayed
	And large print version of main maps should be displayed
	And all accessibility facilities should be displayed

	@ignore
Scenario: Customer is able to click on the Nearby icon or tab or link
	Given customer is on plan a widget
	When a customer navigates to click on the Nearby icon
	And customer populates the current location field with 'New Cross'
	And customer clicks on the Go Button
	Then all places close or nearby to New Cross should be displayed
	
@ignore		
Scenario: Customer create a contactless and Oyster account with a valid email address and password
	Given that a customer is on plan a journey widget
	When the customer navigates to the More button
	And customer clicks on the drop down arrow next to More button
	And customer clicks on Contactless and Oyster account link at bottom right of the page
	And the Contactless and Oyster account page gets displayed
	And customer navigates to click on create an account link
	And Your account page should be displayed
	And customer type in a valid email address to the email address field
	And customer type in a valid password to the password field
	And customer click on create an account button
	Then customer should be able to create an account

	@ignore
Scenario: Customer unable to create a contactless and Oyster account with an existing email address
	Given that a customer is on plan a journey widget
	When the customer navigates to the More button
	And customer clicks on the drop down arrow next to More button
	And customer clicks on Contactless and Oyster account link at bottom right of the page
	And the Contactless and Oyster account page gets displayed
	And customer navigates to click on create an account link
	And Your account page should be displayed
	And customer type in an existing email address to the email address field
	Then customer should be directed to contact TfL customer services on '03432221234'
	
	@ignore
Scenario: Customer with an existing profile able to sign in to the account with a valid email address
	Given that a customer has an existing account
	And the customer is on plan a journey widget
	When the customer clicks on the Sign in button
	And the customer populates the email field with a valid email address
	And the customer populates the password field with a valid password
	And the customer clicks on sign in button
	And the customer complete all the required authentications
	Then customer should be able to access his account

	@ignore
Scenario: Customer with an existing profile unable to sign in with an invalid email address
	Given that a customer has an existing account
	And the customer is on plan a journey widget
	When the customer clicks on the Sign in button
	And the customer populates the email field with a non-valid email address
	And the customer populates the password field with a valid password
	And the customer clicks on sign in button
	Then 'Enter an email address in the right format' should be displayed

	@ignore
Scenario: Customer with an existing profile unable to sign in with an invalid password
	Given that a customer has an existing account
	And the customer is on plan a journey widget
	When the customer clicks on the Sign in button
	And the customer populates the email field with a valid email address
	And the customer populates the password field with a wrong password
	And the customer clicks on sign in button
	Then 'Incorrect details Check your email and password and try again' should be displayed
	
	@ignore
Scenario: Customer with an existing profile is able to reset password
	Given that a customer has an existing account
	And the customer is on plan a journey widget
	And the customer navigates to 'Your account' page
	When the customer completes the Email address field
	And click on the 'Forgot password' link
	Then the Forgot password page should be displayed
	And the customer is able to complete the Forgot password process


## Additional Scenarios For Non-Functional Requirements

 @ignore
Scenario: Maintain performance under load 
	Given the plan a journey widget is operational
	When 1000 users simultaneously access the system
	And for a period of 30minutes
	Then the average response time should be less than 5 seconds
	And server resource utilization should not exceed 85%

	@ignore
Scenario: Access to the journey planner page
	Given the system is loaded
	When a customer inputs a non-existing station
	And plan a journey with those stations
    Then the request should display an error message

	@ignore
Scenario: Usability 
 	Given a new user visits journey planner widget for the first time
	When the user navigates through the journey planner
	Then the user should be able to find help section within 4 clicks 
    And able to navigate to contact us within 5 clicks as another option

	@ignore
Scenario: Reliability 
	Given the system is operational
	When a failure occurs in one component
	Then the system should recover within 2 minutes

	@ignore
Scenario: Scalability
	Given the journey planner application is deployed
	When the number of users increases to 100,000 concurrently
	Then the journey planner system should maintain response times under 3 seconds

	@ignore
Scenario: Availability
	Given the journey planner application is hosted
	When monitoring the uptime over a week
	Then the journey planner application should have an uptime of 99.99%

	@ignore
Scenario: User can refresh a list of stations on Plan a journey page widget
	Given I am on the plan a journey page
	When I refresh the page
	Then I see the most current list of stations

	@ignore
Scenario: User can quickly refresh the list of stations 
	Given I am on the plan a journey page
	When I refresh the page
	Then I see the most current list of stations
	And I should have to wait no longer than the max acceptable wait time

	@ignore
Scenario: Timeouts are logged when refreshing
	Given I am on the contacts page
	And I have refreshed the page
	When refreshing takes more that the max acceptable time
	Then the problem is logged
