Создать программу, имитирующую рабочий процесс автоматизированного пункта
контроля скорости дорожного движения (далее контрольный пункт, КП) на трассе.
Через КП проезжают различные автомобили, для каждого из которых автоматически
регистрируются его номер, цвет и тип кузова, наличие пассажира на переднем сидении
и скорость. Эти данные отображаются на экране оператора.

Между проезжающими машинами может быть произвольный промежуток
времени от 0,5 до 5 сек. Машины, двигающиеся со скоростью выше 110 км/ч,
отмечаются на экране надписью «Превышение скорости». Рабочее место оператора
подключено к региональной системе регистрации угонов и имеет список номеров
угнанных машин. При обнаружении такого автомобиля на экране отображается
надпись «Перехвать.

Завершение имитации реализовать с помощью нажатия любой клавиши
в терминале. Перед выходом из программы необходимо отобразить статистику: общее
количество машин, количество по типам, количество нарушителей, количество
обнаруженных угнанных машин.

Для реализации разных типов машин используйте наследование от базового
класса «Автомобиль» (абстрактный класс «AVehicle»). Каждый из наследников будет
отличаться от других диапазоном скоростей движения. Так, например, пусть легковой
автомобиль будет двигаться со скоростью от 90 до 150, грузовой -- 70-100, автобус --
80-110. В данной работе именно скорость будет отражать разницу в поведении между
машинами и переопределять поведение родительского класса. Эту разницу следует
реалзовать с использованием полиморфизма.

Генерация автомобилей - случайная: регистрационный номер, цвет, тип, наличие
пассажира и скорость получаются случайным образом для каждой машины. Также
подумайте над оптимальным методом, в котором будет размещена логика
по генерации. Для имитации потока автомашин используйте цикл.

