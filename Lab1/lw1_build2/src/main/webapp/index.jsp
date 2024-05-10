<%--
  Created by IntelliJ IDEA.
  User: Home
  Date: 10/22/2023
  Time: 1:41 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Калькулятор деления</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
            background-color: #f0f0f0;
        }
        #calculator {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        input {
            width: 200px;
            margin: 0 10px;
        }
    </style>
</head>
<body>

<div id="calculator">
    <input type="number" id="num1" placeholder="Стоимость велосипеда">
    /
    <input type="number" id="num2" placeholder="Стоимость аренды за 1 час">
    =
    <span id="result">0</span>
    <br>
    <button onclick="calculate()">Посчитать время окупаемости</button>
</div>
<div>
    <a href="/lw1_build2_war_exploded/bikes">Bikes</a>
    <a href="/lw1_build2_war_exploded/customers">Customers</a>
    <a href="/lw1_build2_war_exploded/contracts">Contracts</a>
</div>

<script>
    function calculate() {
        let num1 = parseFloat(document.getElementById('num1').value);
        let num2 = parseFloat(document.getElementById('num2').value);
        if (!isNaN(num1) && !isNaN(num2) && num2 !== 0) {
            let result = num1 / num2;
            document.getElementById('result').textContent = result.toString();
        } else {
            alert('Пожалуйста, введите корректные данные и убедитесь, что делитель не равен нулю.');
        }
    }
</script>

</body>
</html>
