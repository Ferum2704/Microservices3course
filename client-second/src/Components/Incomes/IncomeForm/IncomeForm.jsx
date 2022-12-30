import React from "react";
import { useState } from "react";
import axios from "axios";
import dayjs from "dayjs";
import Stack from "@mui/material/Stack";
import TextField from "@mui/material/TextField";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";

export default function IncomeForm(props) {
  var utc = require("dayjs/plugin/utc");
  dayjs.extend(utc);
  const [incomeForm, setIncomeForm] = useState({
    incomeId: props.data.incomeId,
    sum: props.data.sum,
    categoryName: props.data.categoryName,
    date: props.data.date,
  });

  const createClick = () => {
    axios
      .post("/income/add", {
        id: incomeForm.incomeId,
        sum: incomeForm.sum,
        categoryName: incomeForm.categoryName,
        date: incomeForm.date,
      })
      .then(props.getAllFunction())
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
      .then(props.getAllFunction())
      .catch((error) => console.log(error));
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
  return (
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
  );
}
