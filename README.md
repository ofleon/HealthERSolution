# HealthERSolution
This is a Health Emergency System Built under powerful distributed applications using .NET 6 to understands Solid Principles and Clean Programming Pattern.

The main architecture is based on 3 Microservices under DDD design to comunicate each other following this workflow:

1- The first Microservice (PATIENT) with a Respective REST API will create a Patient and generate object information
2- Second Microservice (HOSPITAL) will receive the Patient when a request is generated from the 3rd Microservice
3- The 3rd Microservice (ERequest) will generate a request to send a Patient to the hospital such a 911 call and the Hambulance should pick the Patient Up.
4- An Azure Function will catch event log to save important information about the Patient in Azure CosmosDb (NoSql Database)
