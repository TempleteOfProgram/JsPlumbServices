# enpoints
1. welcome endpont:
	- https://localhost:5001/workflow 
	- [GET]
	-return : { "code": 200,
    		    "message": "welcome to workflow api."}

2. Get a workflow by id:
	- https://localhost:5001/workflow/getWorkflow?id=3
	- [GET]
	- return: [{"workflowId":3,"name":"workflow3","description":"Descriptionkkkkk","workflow":"{node: form postman data}"}]
	- (or): return:
		{
    		- "code": 404,
    		- "message": "workflow not found.}


3. Save or update a workflow by maiking "put" request:
	- https://localhost:5001/workflow/SaveWorkflow
	- [PUT]
	- JSONBODY= {   
		- "WorkflowId":24,  // update workflow 24
		- "Name": "workflowName",  
		- "Description":"workflow description goes here.",
		- "workflow": {"nodes":[{"id":"pending","top":185,"left":100}],"connections":[]} // as stirng
	- (or)===>
	- JSONBODY= { // create a new workflow
		- "Name": "workflowName",  
		- "Description":"workflow description goes here.",
		- "workflow":"{'node': 'data'}" }
	- return: {
    		- "code": 200,
    		- "message": "workflow 24 saved successfully."}

4. Delete  a workflow by id:
	- https://localhost:5001/workflow/deleteWorkflow?id=1
	- return: {
    		- "code": 200,
    		- "message": "workflow deleted where id = 1."}