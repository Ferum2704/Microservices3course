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
kubectl delete secret mssql-secret
pause