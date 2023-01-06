import React from "react";
import { useEffect, useState } from "react";
import axios from "axios";
import dayjs from "dayjs";
import { Icon } from "@iconify/react";
import IncomeForm from "./IncomeForm/IncomeForm";
import Stack from "@mui/material/Stack";
import TextField from "@mui/material/TextField";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
export default function Incomes() {
    var utc = require("dayjs/plugin/utc");
    dayjs.extend(utc);
  const [incomes, setIncomes] = useState([]);
  const [incomeForm, setIncomeForm] = useState({
    incomeId: 0,
    sum: 0,
    categoryName: "",
    date: dayjs("2022-08-17T21:00:00"),
  });
  const getAll = async () => {
    try {
      const response = await axios.get("income/get-all");
      setIncomes(response.data);
    } catch (error) {
      console.log(error);
    }
  };
  const changeSum = (e) =>
    setIncomeForm((previous) => ({
      ...previous,
      sum: Number(e.target.value),
    }));
  const changeCategoryName = (e) =>
    setIncomeForm((previous) => ({
      ...previous,
      categoryName: e.target.value,
    }));
  const changeDate = (newValue) =>
    setIncomeForm((previous) => ({
      ...previous,
      date: dayjs(newValue).utc(),
    }));
  useEffect(() => {
    axios
      .get("income/get-all")
      .then((response) =>
        setIncomes(response.data).catch((error) => console.log(error))
      );
  }, []);

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
        .delete("/income/delete/" + id)
        .then(getAll())
        .catch((error) => console.log(error));
    }
  };
  const createClick = () => {
    axios
      .post("/income/add", {
        id: incomeForm.incomeId,
        sum: incomeForm.sum,
        categoryName: incomeForm.categoryName,
        date: incomeForm.date,
      })
      .then(getAll())
      .catch((error) => console.log(error));
  };

  const updateClick = () => {
    axios
      .put("/income/update", {
        id: incomeForm.incomeId,
        sum: incomeForm.sum,
        categoryName: incomeForm.categoryName,
        date: incomeForm.date,
      })
      .then(getAll())
      .catch((error) => console.log(error));
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
                  onClick={() => clickUpdate(income)}
                >
                  <Icon icon="material-symbols:edit-outline-sharp" />
                </button>

                <button
                  type="button"
                  className="btn btn-light me-1"
                  onClick={() => clickDelete(income.id)}
                >
                  <Icon icon="material-symbols:delete-outline" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div
        className="modal fade"
        id="exampleModal"
        tabIndex="-1"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-lg modal-dialog-centered">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title">
                {incomeForm.incomeId !== 0 ? "Edit" : "Add"} Income
              </h5>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>

            <div className="modal-body">
              <div className="input-group mb-3">
                <span className="input-group-text">Sum</span>
                <input
                  type="text"
                  className="form-control"
                  value={incomeForm.sum}
                  onChange={changeSum}
                />
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">Category Name</span>
                <input
                  type="text"
                  className="form-control"
                  value={incomeForm.categoryName}
                  onChange={changeCategoryName}
                />
              </div>
              <div className="input-group mb-3">
                <span className="input-group-text">Date</span>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                  <Stack>
                    <DesktopDatePicker
                      label="Date desktop"
                      inputFormat="MM/DD/YYYY"
                      value={incomeForm.date}
                      onChange={changeDate}
                      renderInput={(params) => <TextField {...params} />}
                    />
                  </Stack>
                </LocalizationProvider>
              </div>
              {incomeForm.incomeId === 0 ? (
                <button
                  type="button"
                  className="btn btn-primary float-start"
                  onClick={() => createClick()}
                >
                  Create
                </button>
              ) : null}

              {incomeForm.incomeId !== 0 ? (
                <button
                  type="button"
                  className="btn btn-primary float-start"
                  onClick={() => updateClick()}
                >
                  Update
                </button>
              ) : null}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
