const express = require('express');
const app = express();
const PORT = 8080;

app.get('/health', (req, res) => {
    res.json({ status: "OK", service: "notes-service" });
});

app.get('/notes', (req, res) => {
    res.json([
        { id: 1, title: "Заметка 1", content: "Сделать лабораторную по Docker" },
        { id: 2, title: "Заметка 2", content: "Подготовиться к защите" }
    ]);
});

app.listen(PORT, () => {
    console.log(`Notes service is running on port ${PORT}`);
});