# Microservices_3course
  ## *Lab1*
  - ### Налаштування minikube ###
    - Відкрийте вікно командного рядка від імені адміністратора
    - Введіть команду `minikube start`
    - Введіть команду `minikube tunnel`
    - Не закривайте вікно до закінчення роботи
  
  - ### Розгортання застосунку ###
    - Відкрийте вікно командного рядка
    - Перейдіть у папку `...\Microservices_3course`
    - Запустіть скрипт `lab1script.bat` увівши в `lab1script` в командний рядок та натиснувши `Enter`
   
   **Тепер можна перевіряти роботу застосунку увівши в браузері: </br>**
   - Для клієнта - `localhost/src/index.html`
   - Для сервісу IncomeService `http://localhost/income/ping`
   - Для сервісу SpendingService `http://localhost/spending/ping`
  
