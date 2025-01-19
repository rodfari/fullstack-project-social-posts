import { useContext } from "react";
import { AppContext } from "../../context/AppContext";

const FilterBox = () => {
  const ctx = useContext(AppContext);

  const handleSubmit = (e) => {
    e.preventDefault();
    ctx.setPage(1);
    ctx.setPageSize(15);
    const fd = new FormData(e.target);
    const search = fd.get("search");
    ctx.setSearch(search);
  }

  const sortHandler = (e) => {
    ctx.setPage(1);
    ctx.setPageSize(15);
    ctx.setSort(e.target.value);
  }

  return (
    <>
      <div className="filter-box">
        <div className="filter-box__search">
        <form onSubmit={handleSubmit}>
          <input type="text" placeholder="Search" name="search" />
          <button type="submit">Search</button>
        </form>
        </div>
        <div className="filter-box__sort">
          <select onChange={sortHandler} name="sort">
            <option selected defaultValue="desc">latest</option>
            <option defaultValue="true">trending</option>
          </select>
        </div>
        <div className="filter-box__new">
          <button onClick={ ctx.toggleModal }>New Post</button>
        </div>
      </div>
    </>
  );
};

export default FilterBox;
