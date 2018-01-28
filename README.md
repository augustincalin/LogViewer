# LogViewer
## Install
First you install docker. Then istall docker-compose. Then clone this.
## Docker
Run `docker-compose up`. This will launch 3 containers: Elasticsearch, Logstash, Kibana (see docker-compose.yml):
 What | Where | How
 -------------------------|------|-----
 Elasticsearch (input)   | 5000  | TCP
 Elasticsearch (http)    | 9200  | HTTP
 Logstash (input)        | 5000  | TCP
 Kibana                  | 5601  | HTTP 

### Still to do:
- [ ] complete the environment by launching other containers: web app, sql server?, some x server...
- [ ] install varius beats into these machines 
