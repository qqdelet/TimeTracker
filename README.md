# TimeTracker

# 🕒 TimeTracker - приложение для мониторинга активности
**🇷🇺 Русский | 🇬🇧 English**

---

## 📌 Описание | Description
### 🇷🇺 Русский
**TimeTracker** — это приложение для отслеживания времени, проведенного в разных программах. Оно автоматически фиксирует, когда запускается и закрывается приложение, и записывает эту информацию в локальную базу данных SQLite.

### 🇬🇧 English
**TimeTracker** is an application for tracking the time spent in different programs. It automatically detects when an application starts and stops, recording this data in a local SQLite database.

---

## ⚙️ Как работает? | How does it work?
✅ **🇷🇺** Приложение проверяет список запущенных процессов каждые 5 секунд.  
✅ **🇬🇧** The application checks the list of running processes every 5 seconds.  

**🇷🇺 Русский**  
1. При запуске трекер фиксирует уже работающие процессы.  
2. Каждые 5 секунд он проверяет новые процессы.  
3. Когда процесс закрывается, фиксируется общее время работы.  
4. Данные сохраняются в локальную базу данных `time_tracker.db`.  

**🇬🇧 English**  
1. When launched, the tracker detects already running processes.  
2. Every 5 seconds, it checks for new processes.  
3. When a process closes, the total time is recorded.  
4. Data is stored in the local database `time_tracker.db`.  

---

## 🔍 Какие данные собирает? | What data is collected?
| Поле (RU) | Field (EN) | Описание (RU) | Description (EN) |
|-----------|-----------|---------------|---------------|
| 🖥️ Имя приложения | App Name | Название отслеживаемого приложения | Name of the tracked application |
| 🕒 Время запуска | Last Start | Когда приложение было запущено | When the app was started |
| ⏳ Время завершения | Last Stop | Когда приложение было закрыто | When the app was closed |
| ⌛ Общее время работы | Total Time | Сколько времени работало приложение | Total time the app was active |
| 🔥 Стрик | Streak | Количество дней подряд, когда приложение запускалось | Number of consecutive days the app was used |

---

## 🛠 Функции | Features
✅ **🇷🇺** Автоматический трекинг всех запущенных приложений.  
✅ **🇬🇧** Automatic tracking of all running applications.  

✅ **🇷🇺** Отображение данных в `DataGridView`.  
✅ **🇬🇧** Displaying data in `DataGridView`.  

✅ **🇷🇺** Сохранение информации в SQLite.  
✅ **🇬🇧** Saving information in SQLite.  

✅ **🇷🇺** Индикация работы трекера (Зелёный/Красный статус).  
✅ **🇬🇧** Indicator showing whether the tracker is running (Green/Red status).  

✅ **🇷🇺** Поддержка тёмной и светлой темы.
✅ **🇬🇧** Support for dark and light themes.

✅ **🇷🇺** Автоматическое обновление данных в таблице.
✅ **🇬🇧** Automatic data updates in the table.

✅ **🇷🇺** Система конфигурации с файлом 'config.ini'.
✅ **🇬🇧** Configuration system with 'config.ini' file.

---

# ✅ TimeTracker TODO List

## 🚀 Upcoming Features

| Feature | Description |
|---------|------------|
| **📌 System Tray (Трей)** | Добавить иконку в системный трей, возможность сворачивать приложение в трей, контекстное меню с быстрыми действиями (Старт/Стоп/Настройки/Выход). |
| **🔔 Notifications (Уведомления)** | Добавить уведомления о долгой работе в одном приложении, уведомление при остановке трекера, интерактивные уведомления ('Закрыть приложение?' или 'Продолжить работу?'). |
| **📂 Data Export (Экспорт данных)** | Экспорт статистики в CSV, экспорт в Excel (XLSX), генерация PDF-отчётов с визуализацией данных. |
| **🔄 Auto-Start (Автозапуск)** | Добавить опцию автозапуска при старте Windows, возможность включать/выключать автозапуск в настройках, проверка работы трекера после автозапуска. |

---
