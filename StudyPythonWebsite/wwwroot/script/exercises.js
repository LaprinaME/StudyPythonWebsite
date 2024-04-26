function checkAnswer(exerciseNumber) {
    // Получаем введенный код
    var userInput = document.getElementById('code' + exerciseNumber).value;

    // Определяем правильный ответ для каждого упражнения
    var answers = [
        'print("Привет, мир!")',
        'a = int(input())\nb = int(input())\nprint(a + b)',
        'user_input = input()\nprint(user_input)',
        '# Введите ваш код для выполнения арифметических операций здесь'
    ];

    // Сравниваем введенный код с правильным ответом
    var correctAnswer = answers[exerciseNumber - 1];

    if (userInput.trim() === correctAnswer.trim()) {
        alert('Правильный ответ!');
    } else {
        alert('Неправильный ответ. Попробуйте еще раз.');
    }
}