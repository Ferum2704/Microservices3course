import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import { useNavigate } from "react-router-dom";
function Header() {
  const navigate = useNavigate();
  const [selectedTab, setSelectedTab] = React.useState("/");

  const handleSelectedTabChange = (event, newSelectedTab) => {
    setSelectedTab(newSelectedTab);
    navigate(newSelectedTab);
  };
  return (
    <Box sx={{ width: "100%" }}>
      <Tabs
        value={selectedTab}
        onChange={handleSelectedTabChange}
        variant="fullWidth"
        textColor="secondary"
        indicatorColor="secondary"
      >
        <Tab value="/" label={<div className="iconLabel">Spendings</div>} />
        <Tab
          value="/Incomes"
          label={<div className="iconLabel">Incomes</div>}
        />
      </Tabs>
    </Box>
  );
}

export default Header;
