import { useContext, useEffect, useState } from "react";
import { getUsers } from "../../services/api-services";
import { AppContext } from "../../context/AppContext";

const Sidebar = () => {
  const ctx = useContext(AppContext);
  const [users, setUsers] = useState([]);
  // const userCookie = document.cookie
  //   .split(";")
  //   .find((cookie) => cookie.includes("user"));
  // const user = JSON.parse(userCookie.split("=")[1]);

  useEffect(() => {
    getUsers().then((data) => {
      setUsers(data);
    });
  }, []);

  return (
    <div className="sidebar">
      <div className="user">
        <div className="user__wrapper">
          <div className="user__avatar"></div>
          <div className="user__name">{ctx.user.userName}</div>
        </div>
      </div>
      <div className="sidebar__menu">
        <select className="sidebar__select" onChange={ (event) => ctx.setCurrentUser(event.target.value) }>
          <option value="" >Switch user</option>
          {users.map((user) => (
            <option key={user.id} value={user.id}>
              {user.userName}
            </option>
          ))}
        </select>
      </div>
    </div>
  );
};

export default Sidebar;
