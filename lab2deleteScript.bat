@echo
kubectl delete deploy client-deployment
kubectl delete service client-service
kubectl delete ingress client-ingress
kubectl delete deploy spending-deployment
kubectl delete service spending-service
kubectl delete ingress spending-ingress
kubectl delete deploy income-deployment
kubectl delete service income-service
kubectl delete ingress income-ingress
kubectl delete configmap mssql-config
kubectl delete service mssql-service
kubectl delete deploy mssql-deployment
kubectl delete pvc mssql-pvc
kubectl delete secret mssql-secret
docker rmi ferumchick/microservices3course:spending0.1
docker rmi ferumchick/microservices3course:income0.1
docker rmi ferumchick/microservices3course:client0.1
docker rmi client:0.1 --force
docker rmi spending:latest --force
docker rmi income:latest --force
docker rmi mcr.microsoft.com/mssql/server:2019-latest
pause