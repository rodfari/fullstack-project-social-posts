import { useContext } from "react";
import { UserContext } from "../../context/UserContext";

const Sidebar = () => {
  const userCtx = useContext(UserContext);

  const selectUserHandler = (event) => {
    if (event.target.value === "switch") return;
    const selectedUser = userCtx.users.find(
      (user) => Number.parseInt(user.id) === Number.parseInt(event.target.value)
    );
    userCtx.setUser(selectedUser);
  };

  return (
    <div className="sidebar">
      <div className="user">
        <div className="user__wrapper">
          <div className="user__avatar"></div>
          <div className="user__name">{userCtx.user.userName}</div>
        </div>
      </div>
      <div className="sidebar__menu">
        <select
          className="sidebar__select"
          onChange={selectUserHandler}
        >
          <option value="switch">Switch user</option>
          {userCtx.users.map((user) => (
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
