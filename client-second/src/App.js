import logo from "./logo.svg";
import "./App.css";
import Spendings from "./Components/Spendings/Spendings";
import Incomes from "./Components/Incomes/Incomes";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import Layout from "./Components/Layout/Layout";
function App() {
  return (
    <div className="App">
      <Router>
        <Layout>
          <Routes>
            <Route path="/" element={<Navigate to="/Spendings" />} />
            <Route path="/Spendings" element={<Spendings />} />
            <Route path="/Incomes" element={<Incomes />} />
          </Routes>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
