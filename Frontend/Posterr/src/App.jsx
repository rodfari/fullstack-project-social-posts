import { useEffect, useState } from "react";
import "./App.sass";
import { getUserById } from "./services/api-services";
import Content from "./components/UI/content/Content";
import Modal from "./components/Modal";
import { AppContext } from "./context/AppContext";
import Sidebar from "./components/UI/Sidebar";

function App() {
  const [user, setUser] = useState(null);
  const [modal, setModal] = useState(false);
  const [updatePost, setUpdatePosts] = useState(false);
  const [sort, setSort] = useState("newest");
  const [search, setSearch] = useState("");
  const [repost, setRepost] = useState(false);
  const [currentUser, setCurrentUser] = useState(null);


  useEffect(() => {
    console.log("currentUser", currentUser);
    getUserById(currentUser ?? 1).then((data) => {
      if (data) {
        const user = JSON.stringify(data); 
        document.cookie = `user=${user}; path=/`;
        setUser(data);
      }
    });
  }, [currentUser]);

 

  const toggleModal = () => {
    setModal((prev) => (prev ? false : true));
  };

  const contextProvide = {
    toggleModal,
    updatePost,
    setUpdatePost: setUpdatePosts,
    sort,
    setSort,
    search,
    setSearch,
    user,
    setUser,
    repost,
    setRepost,
    currentUser,
    setCurrentUser,
  };

  return (
    <>
      { !user && <div className="loading">Loading...</div> }
      { user && 
        <AppContext.Provider value={contextProvide}>
        <div className="container">
          <Sidebar />
          <Content />
        </div>
          {modal && <Modal />}
        </AppContext.Provider>
      }
      
    </>
  );
}

export default App;
