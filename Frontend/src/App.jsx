import { useEffect, useState } from "react";
import { getUsers } from "./services/api-services";
import Modal from "./components/shared/Modal";
import Sidebar from "./components/UI/Sidebar";
import { UserContext } from "./context/UserContext";
import Content from "./components/UI/Content";
import "./App.sass";

function App() {
  const [user, setUser] = useState(null);
  const [users, setUsers] = useState([{}]);



  useEffect(() => {
    getUsers().then((data) => {
      if (data) {
        setUsers(data);
        setUser(data[0]);
      }
    });
  }, []);





  const userContextProvider = {
    user,
    setUser,
    users,
    setUsers,
  };

  return (
    <>
      {!user && <div className="loading">Loading...</div>}
      {user && (
        <UserContext.Provider value={userContextProvider}>
          <div className="container">
            <Sidebar />
            <Content />
          </div>
        </UserContext.Provider>
      )}
    </>
  );
}

export default App;
