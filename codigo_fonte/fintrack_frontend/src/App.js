import React, { useEffect, useState } from "react";
import axios from "axios";

function App() {
  const [produtos, setProdutos] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/produto") // Altere a URL se necessário
      .then(response => setProdutos(response.data))
      .catch(error => console.error("Erro ao buscar produtos", error));
  }, []);

  return (
    <div>
      <h1>Lista de Produtos</h1>
      <ul>
        {produtos.map((produto, index) => (
          <li key={index}>{produto}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
