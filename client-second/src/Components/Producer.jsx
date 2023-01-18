import React from "react";

export default function () {
  const sendMessageToSpendingClick = () => 0;
  const sendMessageToIncomeClick = () => 0;
  return (
    <div className="container mt-5">
      <div className="row justify-content-around">
        <div className="col-3">
          <button
            type="button"
            class="btn btn-primary btn-lg"
            onClick={() => sendMessageToSpendingClick()}
          >
            Send message to Spending Service
          </button>
        </div>
        <div className="col-3">
          <button
            type="button"
            class="btn btn-primary btn-lg"
            onClick={() => sendMessageToIncomeClick()}
          >
            Send message to Income Service
          </button>
        </div>
      </div>
    </div>
  );
}
