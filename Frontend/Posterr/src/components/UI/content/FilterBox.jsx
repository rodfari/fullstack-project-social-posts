import { useContext } from "react";
import { AppContext } from "../../../context/AppContext";

const FilterBox = () => {
  const ctx = useContext(AppContext);

  const handleSubmit = (e) => {
    e.preventDefault();
    const fd = new FormData(e.target);
    const search = fd.get("search");
    ctx.setSearch(search);
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
          <select onChange={(e) => ctx.setSort(e.target.value)}>
            <option value="newest">Newest</option>
            <option value="trending">Trending</option>
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
