# Microservices_3course
  ## *Lab1*
  - Налаштування minikube
    - Відкрийте вікно командного рядка від імені адміністратора
    - Введіть команду `minikube start`
    - Введіть команду `minikube tunnel`
    - Не закривайте вікно до закінчення роботи
  
  - Створення docker образів </br>
  Для створення образів відкрийте нове вікно командного рядка
    - Створення образу клієнта
      - Відкрийте папку `...\Microservices_3course\Client`
      - Виконайте команду `minikube -p minikube docker-env --shell powershell | Invoke-Expression`
      - Виконайте команду `docker build -t client:0.1 -f Dockerfile .`
    - Створення образу сервісу IncomeService
      - Відкрийте папку `...\Microservices_3course\IncomeService\IncomeService`
      - Виконайте команду `minikube -p minikube docker-env --shell powershell | Invoke-Expression`
      - Виконайте команду `docker build -t income -f Dockerfile .`
    - Створення образу сервісу SpendingService
      - Відкрийте папку `...\Microservices_3course\SpendingService\SpendingApp`
      - Виконайте команду `minikube -p minikube docker-env --shell powershell | Invoke-Expression`
      - Виконайте команду `docker build -t spending -f SpendingApp\Dockerfile .`
      
  - Розгортання додатку
    - У вікні командного рядка перейдіть у папку `...\Microservices_3course`
    - Виконайте команду `minikube addons enable ingress` для роботи з ingress
    - Виконайте команду `kubectl apply -f k8s/spending` розгортання застосунку
   
   **Тепер можна перевіряти роботу застосунку увівши в браузері `localhost/src/index.html`**
  
