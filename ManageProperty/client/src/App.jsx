import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import ApartmentCard from "./components/ApartmentCard";
import ApartmentGroup from "./components/ApartmentGroup";
import Header from "./components/Header";
import {Route , Routes} from 'react-router-dom';

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Header />
      <Routes>
        <Route path="/viewApartments" element={<ApartmentGroup />} />
      </Routes>
    </>
  );
}

export default App;
