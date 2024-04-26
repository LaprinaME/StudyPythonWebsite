function toggleContent(testId) {
    var test = document.getElementById(testId);
    if (test.style.display === "none") {
        test.style.display = "block";
    } else {
        test.style.display = "none";
    }
}

function checkAnswers(testId) {
    var test = document.getElementById(testId);
    var questions = test.querySelectorAll('input[type="radio"], input[type="checkbox"], input[type="text"]');
    var score = 0;

    questions.forEach(function (question) {
        if (question.type === 'text') {
            // Проверяем ответ на текстовый вопрос, например, сравниваем со значением
            // если значение равно правильному ответу, увеличиваем счетчик
            if (question.value.trim().toLowerCase() === "python") {
                score++;
            }
        } else {
            // Проверяем ответ на вопрос с выбором
            // если ответ выбран и значение равно 1, увеличиваем счетчик
            if (question.checked && question.value === "1") {
                score++;
            }
        }
    });

    // Выводим результат
    alert("Правильных ответов: " + score + " из " + questions.length);
}