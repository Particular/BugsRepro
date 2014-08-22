# Subscription fails if Endpoint name is API

Seams that if the publisher endpoint name is API when subscriptions requests arrives to the endpoint the subscription is lost.

## Observed behavior

* Starting the API project queues are created as expected:
	* API
	* API.retries
	* API.Subscriptions
* Stop IIS Express;
* Run the Worker process:
	* A subscription rerquest is sent to the API queue;
* Start the API project once again:
	* The subscription is processed but in the API.Subscriptions queue there is nothing;

## Workaround

* In the API project global.asax use the DefineEndpointName method to change the endpoint name to `MyEndpoint`;
* Change the `app.config` of the Worker process accordingly;
* Reproduce using the above steps: everything works as expected and the subscroiption is stored in the Subscriptions queue; 