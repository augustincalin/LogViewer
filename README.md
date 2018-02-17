# LogViewer
This is an example of a log viewer application.  
It starts an enviromnent of applications and services just as an example of how to gather logs from different sources and search throgh it.  


## Install
First you install: docker, docker-compose, Filebeat and Winlogbeat. Then clone this.
## Docker
### Build images
#### ASampleApp
Build the image in ASampleApp:  
`docker build -t asampleapp .`  
This will create an image named asampleapp. 
#### SQL server
Build the image in sql folder: `docker build -t sql-logging .`. This will create an image named sql-logging. It will automatically restore the D4G_Logging database.
#### logstash
Build the image in es/logstash folder: `docker build -t logstash .`. It will create an image named logstash containing the logstash and the jdbc driver.
### Adjustements on the host
- Publish ASampleWeb app
- Copy filebeat.yml from es/filebeat/host into the folder where you installed Filebeat
- Copy winlogbeat.yml from es/winlogbeat/host into the folder where you installed Winlogbeat
### Launch the environment
Run `docker-compose up` . This will launch the following containers: elasticsearch, logstash, kibana, asampleapp and sql-server (see docker-compose.yml):

 What | Where | How
 -----|-------|----
 Elasticsearch (http) | 9200 | HTTP
 Logstash (input) | 5000 | TCP
 Kibana | 5601 | HTTP 
 asampleapp | x | x 
 sql-server | x | x 
#### Other adjustements (in containers)
##### Templates
Don't forget to install the templates for Filebeat and Winlogbeat! Export the templates with:
- `.\winlogbeat.exe export template --es.version 6.2.1 | Out-File -Encoding UTF8 winlogbeat.template.json`
- `.\filebeat.exe export template --es.version 6.2.1 | Out-File -Encoding UTF8 filebeat.template.json` 
Then run the `docker-compose up` (so that the ES is running) and install the previously exported templates:
- `Invoke-RestMethod -Method Put -ContentType "application/json" -InFile filebeat.template.json -Uri http://localhost:9200/_template/filebeat-6.2.1`
- `Invoke-RestMethod -Method Put -ContentType "application/json" -InFile winlogbeat.template.json -Uri http://localhost:9200/_template/winlogbeat-6.2.1` 
##### ASampleApp
In order to connect to the container, execute `docker exec -it asampleapp bash` (after you launch it via `docker-compose up`), then manually start the application: `dotnet ASampleApp.dll`. Start generating entries in the log.
Also don't forget to start the filebeat service on this image: `service filebeat start`

After that you can use kibana to define an index and see the data: http://localhost:5601.


#### Usefull commands
- `docker exec -it container_name` bash to connect to the container with the name _container_name_
- `docker build -t image_name .` to build an image with the name _image_name_
- `docker container run --name container_name image_name` starts a container with the name _container_name_ from the image _image_name_
- `docker inspect container_name` to find the IP address of specified container
- `logstash -f test.config<data` to test grok against logstash