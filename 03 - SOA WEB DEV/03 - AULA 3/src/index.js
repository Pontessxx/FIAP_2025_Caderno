const express = require("express");

const axios = require("axios")


const app = express();

const PORT = 3000;

//endpoint para buscar o endereço pelo CEP

app.get('/cep/:cep', async (req, res) => {
    const {cep} = req.params;


    try{
        const response = await axios.get('https://viacep.com.br/ws/${cep}/json/')

    }
})