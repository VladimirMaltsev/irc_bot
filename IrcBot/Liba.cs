﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Lib
{
    int current_prediction = 0;   
    string[] predictions = {
                                "Очень удачное время для воплощения любовных желаний.",
                                "Исполнение заветного желания уже близко.",
                                "Ждет вас счастье, если поставите всем 5.",
                                "Кто-то будет о Вас очень нежно заботиться.",
                                "Упс... Для вас ничего",
                                "Уделите больше внимание своей внешности! Ведь скоро ВЕСНА!!!",
                                "Какого ждешь расклада от планет? Судьба тебя подарком удивит! Спать на работе больше - смысла нет, встречу волшебную судьба тебе сулит!",
                                "Вас ждет взаимная и крепкая любовь!",
                                "Ваши романтические мечты сбудутся!","Любовь, время и терпение - три великих врача. Всегда помните об этом!",
                                "Романтика переместит вас в новом направлении.",
                                "Каждый день и каждый час , кто-то думает о вас!",
                                "Пряники да сладости, будет много радости. ",
                                "Появится скоро вдруг , у тебя самый лучший друг. ",
                                "Солнце вновь и счастье вновь - встретишь новую любовь. ",
                                "С сегодняшнего дня вы находитесь под покровительством планеты Венера, которая преподнесет вам новую неожиданную любовь.",
                                "Вам нужно срочно поцеловать свою половинку и при этом загадать желание с закрытыми глазами!",
                                "Кто-то расставил на Вас любовный капкан!",
                                "Очень удачное время для воплощения любовных желаний.",
                                "Исполнение заветного желания уже близко.",
                                "Кто-то будет о Вас очень нежно заботиться.",
                                "Упс... Для вас ничего",
                                "Уделите больше внимание своей внешности! Ведь скоро ВЕСНА!!!",
                                "Какого ждешь расклада от планет? Судьба тебя подарком удивит! Спать на работе больше - смысла нет, встречу волшебную судьба тебе сулит!",
                                "Вас ждет взаимная и крепкая любовь!",
                                "Ваши романтические мечты сбудутся!",
                                "Мысли о любви помогут Вам свернуть горы !"

    };

    public string GetPrediction()
    {
        return predictions[current_prediction++ % predictions.Length];
    }
    
}
