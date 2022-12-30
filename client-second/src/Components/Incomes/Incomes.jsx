import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";
import dayjs from "dayjs";
import { Icon } from "@iconify/react";
import IncomeForm from "./IncomeForm/IncomeForm";
export default function Incomes() {
  const [incomes, setIncomes] = useState([]);
  const [incomeForm, setIncomeForm] = useState({
    incomeId: 0,
    sum: 0,
    categoryName: "",
    date: dayjs("2022-08-08"),
  });
  const getAll = async () => {
    try {
      const response = await axios.get("income/get-all");
      setIncomes(response.data);
    } catch (error) {
      alert(error);
    }
  };
  useEffect(() => getAll(), []);

  const clickUpdate = (income) =>
    setIncomeForm((previous) => ({
      ...previous,
      incomeId: income.id,
      sum: income.sum,
      categoryName: income.categoryName,
      date: dayjs(income.date),
    }));
  const clickDelete = (id) => {
    if (window.confirm("Are you sure?")) {
      axios
        .delete("/income/detete/" + id)
        .then(getAll())
        .catch((error) => alert(error));
    }
  };

  return (
    <div>
      <button
        type="button"
        className="btn btn-primary m-2 float-end"
        data-bs-toggle="modal"
        data-bs-target="#exampleModal"
      >
        Add Income
      </button>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Sum</th>
            <th>Category Name</th>
            <th>Date</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {incomes.map((income) => (
            <tr key={income.id}>
              <td>{income.sum}</td>
              <td>{income.categoryName}</td>
              <td>{income.date}</td>
              <td>
                <button
                  type="button"
                  className="btn btn-light me-1"
                  data-bs-toggle="modal"
                  data-bs-target="#exampleModal"
                  onClick={clickUpdate(income)}
                >
                  <Icon icon="material-symbols:edit-outline-sharp" />
                </button>

                <button
                  type="button"
                  className="btn btn-light me-1"
                  onClick={clickDelete(income.id)}
                >
                  <Icon icon="material-symbols:delete-outline" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <IncomeForm data={incomeForm} getAllFunction={getAll} />
    </div>
  );
}
