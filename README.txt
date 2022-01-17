open folder: /src/docker-Elastic
execute: docker-compose up -d
Return:
  elasticsearch is up-to-date
  kibana is up-to-date

validate:
http://localhost:5601/app/home#/
http://localhost:9200/
https://localhost:44388/swagger

Postman Collections
https://www.getpostman.com/collections/a703ce7a20269540f07a