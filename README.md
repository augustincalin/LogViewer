# LogViewer
## Install
First you install docker. Then install docker-compose. Don't forget about nc for windows! Then clone this.
## Docker
Don't forget to install the templates for Filebeat and Winlogbeat! Export the templates with:
- `.\winlogbeat.exe export template --es.version 6.2.1 | Out-File -Encoding UTF8 winlogbeat.template.json`
- `.\filebeat.exe export template --es.version 6.2.1 | Out-File -Encoding UTF8 filebeat.template.json` 
logstash -f test.config<data
Then run the `docker-compose up` (so that the ES is running) then install the exported templates:
- `Invoke-RestMethod -Method Put -ContentType "application/json" -InFile filebeat.template.json -Uri http://localhost:9200/_template/filebeat-6.2.1`
- `Invoke-RestMethod -Method Put -ContentType "application/json" -InFile winlogbeat.template.json -Uri http://localhost:9200/_template/winlogbeat-6.2.1` 

### ASampleApp
Build the image in ASampleApp: `docker build -t asampleapp .`. This will create an image named asampleapp. In order to connect to the container, execute `docker exec -it aspnet bash` (after you launch it via `docker-compose up`), then launch the application: `dotnet ASampleApp.dll`. Start generating entries in the log.
### SQL server
Build the image in sql folder: `docker build -t sql-logging .`. This will create an image named sql-logging.
### Docker compose
Run `docker-compose up`. This will launch XXX containers: Elasticsearch, Logstash, Kibana, asampleapp (see docker-compose.yml):

 What | Where | How
 -----|-------|----
 Elasticsearch (input) | 5000 | TCP
 Elasticsearch (http) | 9200 | HTTP
 Logstash (input) | 5000 | TCP
 Kibana | 5601 | HTTP 
 asampleapp | x | x 
 sql-server | x | x 

Then you have to feed elasticsearch via logstash: `echo "abc" | nc localhost 5000`. 

After that you can use kibana to define an index and see the data: http://localhost:5601.

#### Find sql-server IP
Run `docker inspect sql-server` and find the IP. Connect via SSMS just to verify the database is in place, inside the container.

### Still to do:
- [ ] complete the environment by launching other containers: web app, sql server?, some x server...
- [ ] install varius beats into these machines 
