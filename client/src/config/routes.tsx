import React from "react";
import { createBrowserRouter } from "react-router-dom";

const Homepage = React.lazy(() => import("../Pages/Homepage"));
const Admin = React.lazy(() => import("../Pages/Admin"));

export const routes = createBrowserRouter([
  {
    path: "/",
    element: <Homepage />,
  },
  {
    path: "/admin",
    element: <Admin />,
  },
]);
