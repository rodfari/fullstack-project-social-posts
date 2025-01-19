import { useEffect, useState } from "react";
import "./App.sass";
import { getUsers } from "./services/api-services";
import Modal from "./components/shared/Modal";
import { AppContext } from "./context/AppContext";
import Sidebar from "./components/UI/Sidebar";
import { UserContext } from "./context/UserContext";
import Content from "./components/UI/Content";

function App() {
  const [user, setUser] = useState(null);
  const [users, setUsers] = useState([{}]);
  const [modal, setModal] = useState(false);
  const [updatePost, setUpdatePost] = useState(false);
  const [sort, setSort] = useState("newest");
  const [search, setSearch] = useState("");
  const [repost, setRepost] = useState(false);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(15);

  useEffect(() => {
    getUsers().then((data) => {
      if (data){
        setUsers(data);
        setUser(data[0]);
      }
    });
  }, []);

  const toggleModal = () => {
    setModal((prev) => (prev ? false : true));
  };

  const contextProvide = {
    page,
    setPage,
    pageSize,
    setPageSize,
    toggleModal,
    updatePost,
    setUpdatePost,
    sort,
    setSort,
    search,
    setSearch,
    repost,
    setRepost,
  };

  const userContextProvider = {
    user,
    setUser,
    users,
    setUsers
  };

  return (
    <>
      {!user && <div className="loading">Loading...</div>}
      {user && (
        <AppContext.Provider value={contextProvide}>
          <UserContext.Provider value={ userContextProvider }>
            <div className="container">
              <Sidebar />
              <Content />
            </div>
            {modal && <Modal />}
          </UserContext.Provider>
        </AppContext.Provider>
      )}
    </>
  );
}

export default App;
