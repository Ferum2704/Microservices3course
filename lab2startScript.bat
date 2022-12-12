@echo
docker pull ferumchick/microservices3course:spending0.1
docker tag ferumchick/microservices3course:spending0.1 spending:latest
docker pull ferumchick/microservices3course:income0.1
docker tag ferumchick/microservices3course:income0.1 income:latest
docker pull ferumchick/microservices3course:client0.1
docker tag ferumchick/microservices3course:client0.1 client:0.1
docker pull mcr.microsoft.com/mssql/server:2019-latest
minikube addons enable ingress
kubectl apply -f k8s/spending
kubectl apply -f k8s/income
kubectl apply -f k8s/client
kubectl apply -f k8s/mssql
pause