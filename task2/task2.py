import unittest


def search_insert(nums, target):
    left = 0
    right = len(nums) - 1
    while left <= right:
        mid = int((left + right) / 2)
        if nums[mid] == target:
            return mid
        if target > nums[mid]:
            left = mid + 1
        else:
            right = mid - 1
    return -1


class TestSearchInsert(unittest.TestCase):
    def test_search_insert_existing(self):
        nums = [1, 3, 5, 6]
        target = 5
        self.assertEqual(search_insert(nums, target), 2)

    def test_search_insert_not_existing(self):
        nums = [1, 3, 5, 6]
        target = 2
        self.assertEqual(search_insert(nums, target), -1)

    def test_search_insert_target_last(self):
        nums = [1, 3, 5, 6]
        target = 6
        self.assertEqual(search_insert(nums, target), 3)

    def test_search_insert_target_first(self):
        nums = [1, 3, 5, 6]
        target = 1
        self.assertEqual(search_insert(nums, target), 0)

    def test_search_insert_empty_list(self):
        nums = []
        target = 5
        self.assertEqual(search_insert(nums, target), -1)

    def test_search_insert_single_element(self):
        nums = [1]
        target = 1
        self.assertEqual(search_insert(nums, target), 0)

    def test_search_insert_target_greater_than_all(self):
        nums = [1, 3, 5, 6]
        target = 7
        self.assertEqual(search_insert(nums, target), -1)

    def test_search_insert_target_smaller_than_all(self):
        nums = [1, 3, 5, 6]
        target = 0
        self.assertEqual(search_insert(nums, target), -1)


if __name__ == '__main__':
    unittest.main()
